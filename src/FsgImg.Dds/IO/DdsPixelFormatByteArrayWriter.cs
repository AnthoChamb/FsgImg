using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsPixelFormatByteArrayWriter : IDdsPixelFormatWriter
    {
        private readonly byte[] _buffer;
        private readonly int _offset, _count;

        public DdsPixelFormatByteArrayWriter(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public DdsPixelFormatByteArrayWriter(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public void Write(IDdsPixelFormat ddsPixelFormat)
        {
            var span = new Span<byte>(_buffer, _offset, _count);
            var start = 0;

            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsPixelFormat.Size);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), (uint)ddsPixelFormat.Flags);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), (uint)ddsPixelFormat.FourCc);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsPixelFormat.RgbBitCount);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsPixelFormat.RBitMask);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsPixelFormat.GBitMask);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsPixelFormat.BBitMask);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsPixelFormat.ABitMask);
        }

        public Task WriteAsync(IDdsPixelFormat ddsPixelFormat, CancellationToken cancellationToken = default)
        {
            Write(ddsPixelFormat);
            return Task.CompletedTask;
        }
    }
}
