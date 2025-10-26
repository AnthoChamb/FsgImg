using FsgImg.Pvr.Abstractions.Interfaces;
using FsgImg.Pvr.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Pvr.IO
{
    public class PvrHeaderByteArrayWriter : IPvrHeaderWriter
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public PvrHeaderByteArrayWriter(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public PvrHeaderByteArrayWriter(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public void Write(IPvrHeader pvrHeader)
        {
            var span = new Span<byte>(_buffer, _offset, _count);

            BinaryPrimitives.WriteUInt32LittleEndian(span, pvrHeader.Version);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32LittleEndian(span, (uint)pvrHeader.Flags);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt64LittleEndian(span, (uint)pvrHeader.PixelFormat);
            span = span.Slice(sizeof(ulong));

            BinaryPrimitives.WriteUInt32LittleEndian(span, (uint)pvrHeader.ColourSpace);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32LittleEndian(span, (uint)pvrHeader.ChannelType);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32LittleEndian(span, pvrHeader.Height);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32LittleEndian(span, pvrHeader.Width);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32LittleEndian(span, pvrHeader.Depth);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32LittleEndian(span, pvrHeader.NumSurfaces);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32LittleEndian(span, pvrHeader.NumFaces);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32LittleEndian(span, pvrHeader.MipmapCount);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32LittleEndian(span, pvrHeader.MetadataSize);
        }

        public Task WriteAsync(IPvrHeader pvrHeader, CancellationToken cancellationToken = default)
        {
            Write(pvrHeader);
            return Task.CompletedTask;
        }
    }
}
