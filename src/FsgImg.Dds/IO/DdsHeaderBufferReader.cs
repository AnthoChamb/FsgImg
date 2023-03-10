using FsgImg.Dds.Enums;
using FsgImg.Dds.Exceptions;
using FsgImg.Dds.Interfaces;
using FsgImg.Dds.Interfaces.Factories;
using FsgImg.Dds.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsHeaderBufferReader : IDdsHeaderReader
    {
        private readonly byte[] _buffer;
        private readonly IDdsPixelFormatBufferReaderFactory _factory;
        private readonly int _offset, _count;

        public DdsHeaderBufferReader(byte[] buffer, IDdsPixelFormatBufferReaderFactory factory) : this(buffer, factory, 0, buffer.Length)
        {
        }

        public DdsHeaderBufferReader(byte[] buffer, IDdsPixelFormatBufferReaderFactory factory, int offset, int count)
        {
            _buffer = buffer;
            _factory = factory;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public IDdsHeader Read()
        {
            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count);
            var start = 0;

            var ddsHeader = new DdsHeader();
            var size = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            if (size != DdsConstants.DdsHeaderSize)
            {
                throw new InvalidDdsHeaderSizeException(size);
            }
            ddsHeader.Size = size;

            ddsHeader.Flags = (DdsHeaderFlags)BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsHeader.Height = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsHeader.Width = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsHeader.PitchOrLinearSize = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsHeader.Depth = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsHeader.MipmapCount = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));

            for (var i = 0; i < ddsHeader.Reserved.Length; i++)
            {
                ddsHeader.Reserved[i] = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            }

            using (var ddsPixelFormatReader = _factory.Create(_buffer, start += DdsConstants.DdsPixelFormatSize, DdsConstants.DdsPixelFormatSize))
            {
                ddsHeader.PixelFormat = ddsPixelFormatReader.Read();
            }

            ddsHeader.Caps = (DdsCapsFlags)BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsHeader.Caps2 = (DdsCaps2Flags)BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsHeader.Caps3 = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsHeader.Caps4 = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));
            ddsHeader.Reserved2 = BinaryPrimitives.ReadUInt32LittleEndian(span.Slice(start += sizeof(uint), sizeof(uint)));

            return ddsHeader;
        }

        public Task<IDdsHeader> ReadAsync()
        {
            return Task.FromResult(Read());
        }
    }
}
