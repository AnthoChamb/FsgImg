using FsgImg.Dds.Enums;
using FsgImg.Dds.Exceptions;
using FsgImg.Dds.Interfaces;
using FsgImg.Dds.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsPixelFormatBufferReader : IDdsPixelFormatReader
    {
        private readonly byte[] _buffer;
        private readonly int _offset, _count;

        public DdsPixelFormatBufferReader(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public DdsPixelFormatBufferReader(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public IDdsPixelFormat Read()
        {
            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count);
            var start = 0;

            var ddsPixelFormat = new DdsPixelFormat();
            var size = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            if (size != DdsConstants.DdsPixelFormatSize)
            {
                throw new InvalidDdsPixelFormatSizeException(size);
            }
            ddsPixelFormat.Size = size;

            ddsPixelFormat.Flags = (DdsPixelFormatFlags)BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsPixelFormat.FourCc = (DdsFourCc)BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsPixelFormat.RgbBitCount = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsPixelFormat.RBitMask = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsPixelFormat.GBitMask = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsPixelFormat.BBitMask = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsPixelFormat.ABitMask = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            return ddsPixelFormat;
        }

        public Task<IDdsPixelFormat> ReadAsync()
        {
            return Task.FromResult(Read());
        }
    }
}
