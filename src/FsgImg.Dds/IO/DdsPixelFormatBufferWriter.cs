using FsgImg.Dds.Interfaces;
using FsgImg.Dds.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsPixelFormatBufferWriter : IDdsPixelFormatWriter
    {
        private readonly byte[] _buffer;
        private readonly int _offset, _count;

        public DdsPixelFormatBufferWriter(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public DdsPixelFormatBufferWriter(byte[] buffer, int offset, int count)
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

            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsPixelFormat.Size);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), (uint)ddsPixelFormat.Flags);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), (uint)ddsPixelFormat.FourCc);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsPixelFormat.RgbBitCount);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsPixelFormat.RBitMask);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsPixelFormat.GBitMask);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsPixelFormat.BBitMask);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)), ddsPixelFormat.ABitMask);
        }

        public Task WriteAsync(IDdsPixelFormat ddsPixelFormat)
        {
            Write(ddsPixelFormat);
            return Task.CompletedTask;
        }
    }
}
