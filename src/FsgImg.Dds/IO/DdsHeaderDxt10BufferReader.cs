using FsgImg.Dds.Abstractions.Enums;
using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsHeaderDxt10BufferReader : IDdsHeaderDxt10Reader
    {
        private readonly byte[] _buffer;
        private readonly int _offset, _count;

        public DdsHeaderDxt10BufferReader(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public DdsHeaderDxt10BufferReader(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public IDdsHeaderDxt10 Read()
        {
            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count);
            var start = 0;

            var ddsHeaderDxt10 = new DdsHeaderDxt10();
            ddsHeaderDxt10.DxgiFormat = (DxgiFormat)BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsHeaderDxt10.Dimension = (DdsDimension)BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsHeaderDxt10.MiscFlags = (DdsMiscFlags)BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsHeaderDxt10.ArraySize = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsHeaderDxt10.MiscFlags2 = (DdsMiscFlags2)BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            return ddsHeaderDxt10;
        }

        public Task<IDdsHeaderDxt10> ReadAsync()
        {
            return Task.FromResult(Read());
        }
    }
}
