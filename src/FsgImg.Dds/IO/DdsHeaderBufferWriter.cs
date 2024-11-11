using FsgImg.Dds.Abstractions;
using FsgImg.Dds.Abstractions.Interfaces;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading.Tasks;

namespace FsgImg.Dds.IO
{
    public class DdsHeaderBufferWriter : IDdsHeaderWriter
    {
        private readonly byte[] _buffer;
        private readonly IDdsPixelFormatBufferWriterFactory _factory;
        private readonly int _offset, _count;

        public DdsHeaderBufferWriter(byte[] buffer, IDdsPixelFormatBufferWriterFactory factory) : this(buffer, factory, 0, buffer.Length)
        {
        }

        public DdsHeaderBufferWriter(byte[] buffer, IDdsPixelFormatBufferWriterFactory factory, int offset, int count)
        {
            _buffer = buffer;
            _factory = factory;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public void Write(IDdsHeader ddsHeader)
        {
            var span = new Span<byte>(_buffer, _offset, _count);
            var start = 0;

            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsHeader.Size);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), (uint)ddsHeader.Flags);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsHeader.Height);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsHeader.Width);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsHeader.PitchOrLinearSize);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsHeader.Depth);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsHeader.MipmapCount);
            start += sizeof(uint);

            foreach (var reserved in ddsHeader.Reserved)
            {
                BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), reserved);
                start += sizeof(uint);
            }

            using (var ddsPixelFormatWriter = _factory.Create(_buffer, start, DdsConstants.DdsPixelFormatSize))
            {
                ddsPixelFormatWriter.Write(ddsHeader.PixelFormat);
            }
            start += DdsConstants.DdsPixelFormatSize;

            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), (uint)ddsHeader.Caps);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), (uint)ddsHeader.Caps2);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsHeader.Caps3);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsHeader.Caps4);
            start += sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(start, sizeof(uint)), ddsHeader.Reserved2);
        }

        public Task WriteAsync(IDdsHeader ddsHeader)
        {
            Write(ddsHeader);
            return Task.CompletedTask;
        }
    }
}
